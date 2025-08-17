# MemorySharp Pointer Example  

Example of using [MemorySharp](https://github.com/JamesMenetrey/MemorySharp) together with pointers from Cheat Engine.  

## Finding a Pointer in Cheat Engine  
Let’s say you are searching for the ammo count. Cheat Engine shows the pointer chain:  

- **Base address:** `t3.exe + 0x00B38C0C`  
- **1st offset:** `0x80`  
- **2nd offset:** `0x8`  

## Address Calculation Logic  
To get the final address, you need to walk through the chain:  

```c
finalAddress = *((*(Base + 0x80)) + 0x8)
```

## Step by step:
1. Take the **base address** of the process(module) `t3.exe` and add offset `0x00B38C0C`.  
2. Read the **pointer** stored at that address → you get a new address.  
3. Add the **first offset** `0x80` to it.  
4. Read the **pointer** at that address.  
5. Add the **second offset** `0x8`.  
6. The result is the **finalAddress**, which contains the value (for example, ammo count).
