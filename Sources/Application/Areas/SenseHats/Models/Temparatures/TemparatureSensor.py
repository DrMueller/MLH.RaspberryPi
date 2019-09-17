import sys
from sense_hat import SenseHat

sense = SenseHat()


def readTemparature(params):
    temp = sense.get_temperature()
    print(temp)


if __name__ == '__main__':
    args = sys.argv
    args.pop(0)  # Remove file path
    methodName = args.pop(0)  # Pop method name

    globals()[methodName](args)
