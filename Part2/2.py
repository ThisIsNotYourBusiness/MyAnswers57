import math


# prints all the pythagorean triplet combinations by sum
# -- a: int < b: int < c: int
# -- a^2 + b^2 = c^2,    a + b + c = sum
def pythagorean_triplet_by_sum(sum: int) -> None:
    # a + b > c
    # smallest c is 5 in the triplet: (3, 4, 5)
    for c in range(math.floor(sum / 2), 4, -1):
        for b in range(1, math.floor(sum - c)):
            a = sum - c - b
            if pow(a, 2) + pow(b, 2) == pow(c, 2) and a < b < c:
                print(f"{a} < {b} < {c}")
