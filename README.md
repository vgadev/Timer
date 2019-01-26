# Timer
A simple timer utility, meant to be used from the command line.

## Usage instructions
Calling the timer executable without any parameters will display a number indicating the current timestamp.

Calling to the timer executable with a previously generated timestamp, will display the time elapsed since the timestamp was generated.

Calling the timer at with two timestamps, will display the time elapsed between the two timestamps.

```
X:\Projects\Timer\Timer\bin\Release>timer
-8586531437341061325

X:\Projects\Timer\Timer\bin\Release>timer -8586531437341061325
00.00:00:09.968

X:\Projects\Timer\Timer\bin\Release>timer
-8586531437198686681

X:\Projects\Timer\Timer\bin\Release>timer -8586531437341061325 -8586531437198686681
00.00:00:14.237
```
