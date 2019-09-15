import sys
# from sense_hat import SenseHat
from time import sleep
# sense = SenseHat()

def sayHello(params):
  print('hello')

def getEvents(params):
  # print(sense.stick.get_events())
  print("Hello1")

  while True:
    print("Hello")
    sleep(0.1)

def listenForEvents(params):
  while True:
    event = sense.stick.wait_for_event(emptybuffer=True)
    print(event.action + ":" + event.direction)
 
if __name__ == '__main__':
  args = sys.argv
  args.pop(0) # Remove file path
  methodName = args.pop(0) # Pop method name

  globals()[methodName](args)
