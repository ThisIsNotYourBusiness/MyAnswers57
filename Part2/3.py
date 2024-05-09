
# returns if s is a sorted polyndrom
def is_sorted_polyndrom(s: str) -> bool:
    reversed_string = s[::-1]
    previous_char = s[1]

    for i in range(len(s)):
        # check if is polyndrom by reversing the string and comparing to original string
        if s[i] != reversed_string[i]:
            return False

        if previous_char < s[i]:
            return False

        previous_char = s[i]

    return True
