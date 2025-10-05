# csharp-encryptor
## Overview

To further my knowledge in programming, I decided to take on this project of learning to use existing C# libraries to securely encode and then be able to decode files and text strings. This has helped me immensely in learning how to look for guides and write code using an unfamiliar library. 

### Description
This is a basic encryption/decryption program written in C# to demonstrate how the language can be used to perform practical tasks such as file and text encryption.  
The software provides a command-line interface (CLI) for encrypting and decrypting strings or files using AES (Advanced Encryption Standard) with keys saved to or loaded from a file.

### Current Features
- Generate a random AES key & IV and save them to a JSON file.
- Encrypt or decrypt **text** using a saved key file.
- Encrypt or decrypt **files** using a saved key file.
- Base64 output for easy copy/paste of ciphertext.

### Purpose
The primary purpose of writing this software was to:
- Learn and use key C# language features (classes, file I/O, using statements, cryptography APIs).
- Gain experience with encryption concepts like AES, keys, IVs, and Base64 encoding.
- Build a foundation for a more feature-rich encryption tool (including a future potential GUI for this program).

**TODO:** Provide a link to a YouTube demonstration. 4-5 minute demo of the software running and a walkthrough of the code. Focus on what I learned about the language syntax.

[Software Demo Video](http://youtube.link.goes.here)

## Development Environment

### Tools Used
- [.NET SDK](https://dotnet.microsoft.com/) (9) to build and run the console application.
- [Visual Studio Code](https://code.visualstudio.com/) for editing and debugging.
- Git and GitHub for version control and collaboration.

### Language & Libraries
- **Language:** C# (console application targeting .NET 9).
- **Core Libraries:**
  - `System.Security.Cryptography` for AES encryption/decryption.
  - `System.IO` for reading/writing files.
  - `System.Text.Json` for saving/loading keys as JSON.
- No external encryption libraries are used; everything relies on built-in .NET cryptography.


## Useful Websites

- [Microsoft Ignite Encrypting Data](https://learn.microsoft.com/en-us/dotnet/standard/security/encrypting-data)
- [ChatGPT](https://www.chatgpt.com)

## Future Work

- Fix
  - Support a password based encryption
- Add
  - Add secure key storage
  - Add gui based encryption/decryption
