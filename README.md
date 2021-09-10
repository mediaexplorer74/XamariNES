# XamariNES - A Cross-Platform NES Emulator using .Net!

XamariNES is a cross-platform Nintendo Emulator using .Net Standard written in C#. 


My 2 cents: Windows 10 Mobile support (min. os build: 15063)


# Tech moments

I use Microsoft Xamarin platform to utilize it as my UI layer for the emulator. 
This allowed me to write a fairly simple Xamarin.Forms project and quickly target multiple platforms 
(iOS, Android,and Windows 10/Windows 10 Mobile) with only a couple platform specific lines of code. 


# Screenshots
![Shot 1](https://github.com/mediaexplorer74/XamariNES/blob/main/ss_0001.png)

![Shot 2](https://github.com/mediaexplorer74/XamariNES/blob/main/ss_0002.png)

![Shot 3](https://github.com/mediaexplorer74/XamariNES/blob/main/ss_0003.png)


# RnD
The goals for this project were simple:
- Write my fist emulated 8-bit CPU using C#
- Learn the inner workings of the MOS 6502 CPU powering the original Nintendo Entertainment System
- Structure the code to match the NES schematic as closely as possible
- Write the code in a way that made it readable and easier to understand for someone wanting to learn as I was
- Use .Net Standard & Microsoft Xamarin.Forms Framework to make the emulator cross-platform 


# Contribute!
There's still a TON of things missing from this emulator and areas of improvement which I just haven't had the time to get to yet.
- Performance Improvements
- Additional Cartridge Mappers
- Audio Support (for the brave)


# Solution Layout
Projects have a README.MD which expands on the internal functionality and layout of that project. 
I tried to make the solution layout similar to that of the PCB within an actual Nintendo. 
This is why XamariNES uses delegates as the interconnect between the PPU and the CPU 
(representing the PCB traces), which differs from other emulators that might pass the CPU & PPU obejcts 
into one another for reference. 


# A brief summary of each project
- **[XamariNES.Emulator](./XamariNES.Emulator/)** - The System
  - All components are integrated into this project, same as the PCB
  - External facing actons (Controller Input, ROM Loading) go through the Emulator
  - Handles clock synchronization/frame limiting of the CPU & PPU
  - Implements DMA Delegate to handle transfer of data between CPU & PPU
- **[XamariNES.CPU](./XamariNES.CPU/)** - MOS 6502 CPU
  - CPU Core
  - CPU Memory & Registers
  - Access to Cartridge Memory Mapper
- **[XamariNES.PPU](./XamariNES.PPU/)** - NES Picture Processing Unit
  - PPU Core
  - PPU Memory, Registers, and Latches
  - Access to Cartridge Memory Mapper
- **[XamariNES.Cartridge](./XamariNES.Cartridge/)** - NES Cartridge
  - Handles loading the specified ROM and setting up PRG/CHR banks
  - Exposes Memory Mapper used by CPU & PPU to access PRG/CHR memory
  - Interceptor Pattern to allow for hooks/delegates to be mapped to memory offsets
- **[XamariNES.Controller](./XamariNES.Controller/)** - NES Controller
  - Maintains and exposes controller button states
- **[XamariNES.UI.*platform*](./XamariNES.UI/)** - Xamarin.Forms projects for cross-platform UI
  - Xamarin.Forms project containing the UI logic for the emulator
  - Projects specific to their respective platforms (iOS, Android, Windows, macOS)

There are also a couple Common/Support/Testing projects which contain miscellaneous functionality.

# Thanks!
I wanted to put down some thank you's here for folks/projects/websites 
that were invaluable for helping me get this project into a functional state:
- [Eric Nusbaum](https://github.com/enusbaum/)  - Original XamariNES's creator/author
- [XamariNES](https://github.com/enusbaum/XamariNES) - XamariNES for Android, iOS, MacOS, and UWP (Desktop only)
- [Nesdev wiki](http://wiki.nesdev.com/w/index.php/Nesdev_Wiki) - Wealth of detailed, accurate information on all aspects of the Nintendo Entertainment System
- [6502.org](http://www.6502.org/) - Great amount of documentation, errata and tools specific to the MOS 6502 processor. Their interactive simulator specifically was invaluable for debugging the CPU
- [Obelisk.me.uk](http://www.obelisk.me.uk/6502/reference.html) - Concise 6502 documentation, included a lot of it on my opcode documentation
- [NEScafé](https://github.com/GunshipPenguin/nescafe) Emulator by Rhys Rustad-Elliott - I literally would not have been able to untangle how the PPU works without this. Borrowed many of the same routines and logic around memory access and frame rendering


# "CopyLeft" 
XamariNES for W10M is distributed under the MIT License. 