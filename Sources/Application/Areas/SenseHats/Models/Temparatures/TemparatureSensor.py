import sys

def readTemparature(params):
  print(0.5)

if __name__ == '__main__':
  args = sys.argv
  args.pop(0) # Remove file path
  methodName = args.pop(0) # Pop method name

  globals()[methodName](args)
