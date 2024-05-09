import matplotlib.pyplot as plt
import numpy as np


def user_input() -> None:
    number_list = []
    input_data = float(input("Input a number: "))

    while input_data != -1:

        number_list.append(input_data)

        input_data = float(input("Input a number: "))

    positive_count = sum(1 for x in number_list if x > 0)

    sorted_list = number_list.copy()
    sorted_list.sort()

    print(f"count of positive numbers: {positive_count}")
    print(f"sorted numbers: {sorted_list}")

    x = np.arange(0, len(number_list))
    y = np.array(number_list)

    print(f"Pearson Correlation: {np.corrcoef(x, y)}")

    plt.xlabel("Order")
    plt.ylabel("Number")

    plt.plot(y, marker='o')
    plt.show()

