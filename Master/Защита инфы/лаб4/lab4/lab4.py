ecc_pos = (
    [0, 1, 3, 4, 6, 8, 10, 11, 13, 15],
    [0, 2, 3, 5, 6, 9, 10, 12, 13],
    [1, 2, 3, 7, 8, 9, 10, 14, 15],
    [4, 5, 6, 7, 8, 9, 10],
    [11, 12, 13, 14, 15]
)
position16_5 = (11, 4, 1, 0, 0)
ecc_pos21 = (
    [2, 4, 6, 8, 10, 12, 14, 16, 18, 20],
    [2, 5, 6, 9, 10, 13, 14, 17, 18],
    [4, 5, 6, 12, 13, 14, 19, 20],
    [8, 9, 10, 11, 12, 13, 14],
    [16, 17, 18, 19, 20]
)
position21 = (0, 1, 3, 7, 15)


def is_bool(variable):
    new_bool = [x for x in variable if x in ["0", "1"]]
    return len(variable) == len(new_bool)


def counter(position, variable):
    list_bool = list(str(variable))
    ecc_value = []

    for item_on_place in position:
        y = 0
        for x in item_on_place:
            if list_bool[x] == "1":
                y += 1
        if y % 2 == 0:
            ecc_value.append(0)
        else:
            ecc_value.append(1)
    return ecc_value


def to_hamming(value, position=position16_5):
    bit16 = str(value)
    if len(bit16) != 16:
        raise ValueError("Error: количество разрядов не равно 16")
    elif is_bool(bit16) != True:
        raise ValueError("Число не двоичное")

    ecc_date = counter(ecc_pos, bit16)
    print(ecc_date)
    bit16 = list(bit16)

    for x in position:
        bit16.insert(int(x), str(ecc_date.pop()))

    bit21 = ''.join(bit16)
    return bit21


def checker(variable, ecc21_date):
    list_21 = list(str(variable))
    ecc_old = []
    for x in position21:
        a = list_21[x]
        ecc_old.append(int(a))
    error_list = []
    for i, x in enumerate(ecc_old):
        if ecc21_date[i] != x:
            error_list.append(i)
    return error_list


def to_16bit(variable):
    bit21ecc = str(variable)

    if len(bit21ecc) != 21:
        raise ValueError("Error: число разрядов не равно 21")
    elif is_bool(bit21ecc) != True:
        raise ValueError("Число не двоичное")

    ecc21_date = counter(ecc_pos21, bit21ecc)
    err_list = checker(bit21ecc, ecc21_date)

    bit21ecc = list(bit21ecc)
    if err_list:
        err_pos = 0
        for x in err_list:
            err_pos += (position21[x] + 1)
        err_pos -= 1
        if bit21ecc[err_pos] == 0:
            del bit21ecc[err_pos]
            bit21ecc.insert(err_pos, '1')
        else:
            del bit21ecc[err_pos]
            bit21ecc.insert(err_pos, '0')

    for x in [15, 7, 3, 1, 0]:  # Преобразуем число, убирая контроль четности
        del bit21ecc[x]
    bit16_len = ''.join(bit21ecc)
    return bit16_len


def test():
    num1 = "1010111100011011"
    num2 = "1011111011111010"
    num3 = "0100010000111101"

    print("\nCoder test")

    ecc1 = to_hamming(num1)
    print(ecc1)
    ecc2 = to_hamming(num3)
    print(ecc2)
    ecc3 = to_hamming(num2)
    print(ecc3)

    # ecc1 = "101011010010110100001"
    # ecc2 = "101001101110111111110"
    # ecc3 = "110110000100001011101"

    print("\nDecoder test")

    g = to_16bit(ecc1)
    print(g)
    g = to_16bit(ecc2)
    print(g)
    g = to_16bit(ecc3)
    print(g)


test()
