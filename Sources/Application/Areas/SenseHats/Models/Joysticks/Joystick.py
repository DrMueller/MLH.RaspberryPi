import sys
try:
    import queue
except ImportError:
    import Queue as queue
import threading
import requests

from sense_hat import SenseHat
sense = SenseHat()

# Taken from https://stackoverflow.com/questions/48429653/python-returning-values-from-infinite-loop-thread


def _listen(queue):
    while True:
        event = sense.stick.wait_for_event(emptybuffer=True)
        val = event.action + ":" + event.direction
        queue.put(val)


def listen(params):
    q = queue.Queue()
    t1 = threading.Thread(target=_listen, name=_listen, args=(q,))
    t1.start()

    while True:
        value = q.get()
        print(value)


if __name__ == '__main__':
    args = sys.argv
    args.pop(0)  # Remove file path
    methodName = args.pop(0)  # Pop method name

    globals()[methodName](args)
