import time
from flask import Flask
import redis
import os

app = Flask(__name__)
cache = redis.Redis(host='redis', port=6379)

def get_hit_count():
    return cache.incr('hits')

def getFileS():
    file = open('static', 'r')
    string = file.read()
    file.close()
    return string

def getFileM():
    file = open('/mount/mounted', 'r')
    text = file.read()
    file.close()
    return text

@app.route('/')
def hello():
    return 'Hello World! I have been seen {} times.\n'.format(get_hit_count()) + getFileS() + '\n' + getFileM()
