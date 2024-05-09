from mpmath import mp
mp.dps = 10000


# return the first n digits of pi, reversed, as a string
def reverse_n_pi_digits(n: int) -> str:
    return (str(mp.pi)[:(n + 2)])[::-1]

