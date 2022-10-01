# Custom Assembler Emulator

<br />
<br />




# Overview 

A RISC Based Assembler Emulator. Instruction set contains 28 different instructions divided into 4 categories.
Instruction categories are as follows: 

1. Arithmetic Instructions (ADD, SUB, MUL, DIV, MOD, INC, DEC)
2. Logical Instructions (AND, OR, XOR, LSH, RSH, CMP)
3. Registers Instruction (LD, ST, MOV, CLR)
4. Branch and Jump Instructions (JUMP, BEQ, BLSS, BGT, BGE, BLEQ, BNEQ, JSR, RTS)
5. Stack Instructions (PUSH, POP)

There are 4 types of instructions:

1. Zero Operands   -   Instructions operate with Accumulator, result is stored into Accumulator
2. One Operands    -   Instructions operate with one register, result is stored into that one register
3. Two Operands    -   Instructions operate with two register, result is stored into first register
4. Three Operands  -   Instructions operate with three register, result is stored into first register
<br />

# Instruction format

All instructions are aligned to 4 bytes (32bit).<br />

First byte of the instruction contains the OPCODE for the instruction (higher 6 bits) and type of instrcution (lower 2 bits).\
Depending on the type of the instruction the rest of the bytes are used for operands. <br />
Branch and Jump instructions store the label address begenign from the lowest bit( rightmost bit)<br />
<br />
# Configuration of Emulator System
<br />
Emulated System has:

1. 32 General Purpose Registers (32bit Registers). <br />
2. Accumulator Register
3. PC Register
4. SP Register
5. NZCV Register
6. Memory View
7. Build Option
8. Run Option
9. User Stack
10. System Stack
11. 65536 KB of RAM
12. 65536 KB of ROM
<br />






