# Custom Assembler Emulator

<br />
<br />




# Overview 

A RISC Based Assembler Emulator. 
<br />
Instruction set contains 28 different instructions divided into 4 categories.
Instruction categories are as follows: 

1. Arithmetic Instructions (ADD, SUB, MUL, DIV, MOD, INC, DEC)
2. Logic Instructions (AND, OR, XOR, LSH, RSH, CMP)
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

<br />

Instruction Format: <br />

< INSTRUCTION NAME >  < OPERAND1 [opt] > ,   < OPERAND2 [opt] > ,  < OPERAND3 [opt] >
<br />

Branch and Jump Instructions Format: <br />

< INSTRUCTION NAME > < LABEL >

Instruction Format in Binary: <br />

| < [OP_CODE(6bit)] [TYPE(2bit)] > | < FIRST OPERAND > | < SECOND OPERAND > | <THIRD OPERAND> 

  
  
  Branch and Jump Instructions Format in Binary: 
  
| < [OP_CODE(6bit)] [00] >  | < PADDING TO 32 BITS > | < LABEL ADDRESS > |

  <br />
  <br />
First byte of the instruction contains the OPCODE for the instruction (higher 6 bits) and type of instrcution (lower 2 bits).<br />
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
7. Register View
8. Build Option
9. Run Option
10. User Stack
11. System Stack
12. 262144 KB of RAM
13. 262144 KB of ROM
<br />

# Memory Layout

Instructions are stored Into RAM begining from 0x1000 (PC). All instructions are aligned to 4 bytes. Every Instruction has Side Effect of incrementing PC by 4. Memory can only be accessed via Load (LD) and Store (ST) instructions.<br />
RAM is divided into several regions.<br />
First region is System Stack.  System Stack is only used when Jumping to Subroutines (JSR instruction - See Branch and Jump Instructions). This allows nested and recursive subroutine cals, because PC and NZCV registers are stored onto this stack.<br />
Second region is User Stack. User Stack can be accesd via PUSH and POP instrcutions, hence it's User Stack because user can alter Stack.<br />
Both Stacks grow towards higher addresses. <br />
Third region is the rest of the RAM. It is multifuncional region.<br />
There is also ROM.<br />

# Arithmetic Instructions


  Aritihmetic Instructions can be of all four types (Zero, One, Two, Three Address), except INC and DEC (Zero and One Address).<br />
  Arithmetic Instructions are as follows:
  1. Addition - ADD
  2. Subtraction - SUB
  3. Multiplication - MUL
  4. Division - DIV
  5. Modulo - MOD
  6. Increse By One - INC
  7. Decrese By One - DEC

  All Arithmetic Instructions Operation Codes start with three leftmost bits being 001, rest of the bits are indicators. <br />
  
  OP CODES:
      
      ADD <-> 001000
      SUB <-> 001001
      MUL <-> 001010
      DIV <-> 001011
      MOD <-> 001100
      INC <-> 001101
      DEC <-> 001110

  All Arithmetic Instructions can affect NZCV Register. <br />
  
  # Logic Instructions
  
  Logic Instructions can be of all four types (Zero, One, Two, Three Address), except CMP (One and Two Address). <br />
  Logic Instructions are as follows:                                                                            
  1. Bitwise And - AND
  2. Bitwise Or - OR
  3. Bitwise Exclusive Or - XOR
  4. Logic Left Shift - LSH
  5. Arithmetic Right Shift - RSH
  6. Compare - CMP
  
  All Logic Instructions Operation Codes start with three leftmost bits being 000, rest of the bits are indicators. <br />
  
  
  OP CODES:
  
      AND <-> 000001
      OR  <-> 000010
      XOR <-> 000011
      CMP <-> 000100
      LSH <-> 000101
      RSH <-> 000110
  
  All Logic Instructions can affect NZCV Register. <br />
  CMP Instruction ONLY affects NZCV Register. <br />
  
  # Jump And Branch Instructions
  
  
  Jump and Branch Instructions have purpose to jump to certain address given by a Label. <br />
  Jump and Branch Instructions only change the PC value by writing in it the address of a Label in the Instruction. <br />
  Jump Instrcution is unconditional Instruction. <br />
  Branch Instrctuons must satisfy certain condition before branching to the Label. <br />
  Jump to Subroutine (JSR) Instruction jumps to Addres giben by a Label in a Instruction and saves NZCV and PC Registers to System Stack. <br />
  Return from Subroutine (RTS) Instruction returns to the Next Instruction after the JSR Instruction call. RTS pops from System Stack NZCV and PC Registers. <br />
  
  Jump And Branch Instructions are as follows: 
  
  1. JUMP - Unconditional Jump
  2. BEQ  - Branch if Equal (ZF == 1)
  3. BLSS - Branch if Less (CF == 1 ^ NF == 1)
  4. BGT  - Branch if Greater ( (NF == 1 ^ VF == 1) | ZF == 1 )
  5. BGE  - Branch if Greater or Equal (NF == 1 ^ VF == 1)
  6. BLEQ - Branch if Less or Equal ( !((NF == 1 ^ VF == 1) | ZF == 1) )
  7. BNEQ - Branch if Not Equal (ZF == 0)
  8. JSR  - Jump To Subroutine
  9. RTS  - Return From Subroutine
  
  <br />
  
  Jump And Branch Instructions containt only OP CODE and Label address wich is stored starting from the leftmost bit in the Instrctuion Word. <br />
  All of the Jump And Branch Instructions begin with first two rightmost bits being 01, rest of the bits are indicators. <br />
  OP CODES:
      
      JUMP  <-> 010000
      BEQ   <-> 010001
      BLSS  <-> 010010
      BGT   <-> 010011
      BGE   <-> 010100
      BLEQ  <-> 010101
      BNEQ  <-> 010110
      JSR   <-> 010111
      RTS   <-> 011000
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
