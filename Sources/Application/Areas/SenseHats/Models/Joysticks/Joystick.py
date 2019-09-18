import sys
try:
    import queue
except ImportError:
    import Queue as queue

from sense_hat import SenseHat
sense = SenseHat()


def listen(params):
    while True:
        event = sense.stick.wait_for_event(emptybuffer=True)
        val = event.action + ":" + event.direction
        sys.stdout.write(val)
        sys.stdout.flush()


if __name__ == '__main__':
    args = sys.argv
    args.pop(0)  # Remove file path
    methodName = args.pop(0)  # Pop method name

    globals()[methodName](args)
