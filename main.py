import random


def game(computer, user):
    if computer == user:
        return "It's a draw!!"
    elif computer == 's':
        if user == 'g':
            return "You Win!!"
        elif user == 'w':
            return "You Lose!!"
    elif computer == 'w':
        if user == 'g':
            return "You Lose!!"
        elif user == 's':
            return "You Win!!"
    elif computer == 'g':
        if user == 'w':
            return "You Win!!"
        elif user == 's':
            return "You Lose!!"


print("Computer's turn: Snake(s) Water(w) or Gun(g)?")
random_no = random.randrange(1, 4, 1)
if random_no == 1:
    comp = 's'
elif random_no == 2:
    comp = 'w'
else:
    comp = 'g'
you = input("Your Turn: Snake(s) Water(w) or Gun(g)? ")
print(f"Computer chose {comp}")
print(f"You chose {you}")
print(game(comp, you))
