import sys
from sense_hat import SenseHat
import ast

sense = SenseHat()

def showMessage(params):
  text = params[0]
  scrollSpeed =  float(params[1])
  foreground = ast.literal_eval(params[2])
  background = ast.literal_eval(params[3])
  sense.show_message(text, scrollSpeed, foreground, background)

if __name__ == '__main__':
  args = sys.argv
  args.pop(0) # Remove file path
  methodName = args.pop(0) # Pop method name

  globals()[methodName](args)
}