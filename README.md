
# The Truel Problem
Console application to analyze the effectiveness of different strategies of **Truel game**. 

Imagine that you have a three-way duel (or “truel”). The three duelists are named A, B, and C and have accuracy
probabilities of a, b, and c with 0 < a < b < c < 1. The rules of the duel are that the duelists fire sequentially in the
starting order A, B, C (so the least accurate person fires first, etc., and continuing to fire in that order) and the last
person standing wins the duel. If you are duelist A, what strategy should you use to maximize your chance of
winning?

## Common Strategy Choices
If you ask most people what A’s strategy should be when all 3 duelists are alive, there are two common answers:
1) Always fire at the most accurate duelist (C).
2) Fire randomly (since you are the least accurate it doesn’t matter).
To this we’ll add what seems like a bad option:
3) Fire your shot into the ground, wasting it.
