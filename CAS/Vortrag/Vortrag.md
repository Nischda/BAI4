https://www.cs.cornell.edu/home/kleinber/networks-book/
Vergeben: 3,4, 18
Gewählt: 5 - Positive and Negative Relationships 20min vortrag

#Positive and negative Relationships
- Links represent Relationships
- Relationships can be good (or neutral)
- What will propably result out of a defined mix of positive and negative relationships inside a network?

# Setup
- Links are marked with + or -
- local effects will result in global effects
- Mathmatical analysis: Why simple setups will inevitably specific, macroscopig networks

# Structural Balance
## Experiment
- Everybody knows everybody (Complete graph)
- -> Each pair is made of friends or enemies
- image 1
- balanced triangles: 1,3 + (harmonic)
- unbalanced triangles: 0,2 + (social stress)
- a graph is balanced when all contained triangles are balanced
- image 2
- balanced networks have eliminated all unbalanced triangles
- balanced networks may only be having 2 structures:
  - 1 Set of mutual friends
  - 2 sets of mutual friends antagonizing the other sets
- image 3

## Proving the Balance Theorem
- image 4
1. Only mutual friends
2. One negative Edge
  - Pick any Node "A"
  - Put all friends of "A" into Set "X"
  - Put all enemies of "A" into Set "Y"
  Note: X consists only of mutual friends
        Y consists only of mutual friends
        every of X is mutual enemy of every in Y

# skippable: Applications of Structural Balance
- dynamic balancing -> flipping edge polarities to provide balancing
- examples: international Relations
image 5
- Separation applies -> more sets

- example social network
- If A trusts B, B does not have to know A
- If  A trust B and B trusts C, A does hot have to trust C
- Or if A distrusts B and B distrusts C, should A distrust C?

# A weaker Form of Structural Balance
- image 6
- definition: no set of 3 nodes so that 2+ and 1 - )or 2- and 1 +?)
- Multiple sets possible
- mutual antagonism between all sets

# GENERALIZING THE DEFINITION OF STRUCTURAL BALANCE
- image 7
- graph has not to be complete to be divided into 2 parts
- we assume, that all missing edges bewteen sets are negative
- image 8
- image 9

# Signed Graps
- replace sets with bubbles
- remove edge polarities to reassign (all were negative)
- image 10
- place polarities so what at least   x%
- definition

claim:
- image 11
video





b
