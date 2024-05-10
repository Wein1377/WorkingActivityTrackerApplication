import datetime
import json as js
from contextlib import closing

import pika
import psycopg2
from vosk import Model, KaldiRecognizer
import pyaudio


f = open('C:/Users/Nikita/Desktop/Диплом/ClientService/conf.json')

# returns JSON object as
# a dictionary
json = js.load(f)
userId = json["userId"]
rabbitHost = json['rabbitHots']
print(rabbitHost)

stop_words = []
with closing(psycopg2.connect(dbname=json["db"], user=json["dbUser"],
                              password=json["dbPassword"], host=json["dbHost"], port=json["dbPort"])) as conn:
    with conn.cursor() as cursor:
        cursor.execute('SELECT * FROM StopWords')
        for row in cursor:
            print(row[1])
            stop_words += [row[1]]

model = Model(r"vosk-model-ru-0.42")  # полный путь к модели
rec = KaldiRecognizer(model, 8000)
p = pyaudio.PyAudio()
stream = p.open(
    format=pyaudio.paInt16,
    channels=1,
    rate=8000,
    input=True,
    frames_per_buffer=8000
)
stream.start_stream()


def send_message(message):
    connection = pika.BlockingConnection(
        pika.ConnectionParameters(host=str(rabbitHost)))
    channel = connection.channel()

    channel.queue_declare(queue='words')

    channel.basic_publish(exchange='', routing_key='words', body=message)
    print(message)

    connection.close()

count = 0
while True:
    if count == 0:
        print("HERE")
        count += 1
    json = stream.read(4000)
    if len(json) == 0:
        break
    if rec.AcceptWaveform(json):
        result = rec.Result()
        if any(word in str(result).lower() for word in stop_words):
            msg = js.loads(result)
            message = {
                "userId": userId,
                "message": msg['text'],
                "date": str(datetime.datetime.now())
            }
            send_message(str(message))
