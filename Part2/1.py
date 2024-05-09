import math


# returns the length of a number
# -- uses math.log10 to find 10 to the power of x of the number (puts it in abs because undefined in log10 if <= 0)
# -- rounds the result with math.floor
# -- adds 1 because log10(10) = 1
# -- checks if num <= 0 because log10(<=0) is undefined
def num_len(num: int) -> int:
    return 1 if num == 0 else math.floor(math.log10(abs(num))) + 1

import math


# returns the length of a number
# -- uses math.log10 to find 10 to the power of x of the number (puts it in abs because undefined in log10 if <= 0)
# -- rounds the result with math.floor
# -- adds 1 because log10(10) = 1
# -- checks if num <= 0 because log10(<=0) is undefined
def num_len(num: int) -> int:
    return 1 if num == 0 else math.floor(math.log10(abs(num))) + 1

