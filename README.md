# RSA Cipher (C# WinForms)

Educational Windows Forms application that demonstrates how RSA key generation, encryption, and decryption work with `BigInteger`.

Date of dev: 2024-11-20

## Overview

This project provides a simple GUI for:

- generating two random probable primes (`p`, `q`)
- building RSA parameters (`n`, `phi(n)`, `e`, `d`)
- encrypting text into a numeric cipher stream
- decrypting the cipher stream back into text

It is designed for learning and experimentation, not production security.

## Tech Stack

- C#
- .NET Framework 4.7.2
- Windows Forms
- `System.Numerics.BigInteger`

## Project Structure

```text
RSA_cipher.sln
RSA_cipher/
  Program.cs
  Form1.cs
  Form1.Designer.cs
  Functions.cs
  GlobalVariables.cs
  RSA_cipher.csproj
```

## Build and Run

### Visual Studio

1. Open `RSA_cipher.sln`.
2. Restore NuGet packages (if prompted).
3. Build and run the `RSA_cipher` project.

### Command Line

```bash
nuget restore RSA_cipher.sln
msbuild RSA_cipher.sln /p:Configuration=Release
```

Executable output is placed in:

```text
RSA_cipher/bin/Release/
```

## How to Use

1. Click **Random** to generate `p` and `q`, or enter your own values.
2. Click **Check** to validate primality and initialize RSA constants.
3. (Optional) Click **Info** to inspect calculated values (`n`, `phi`, `e`, `d`).
4. Enter plaintext in the left text box.
5. Click **Encrypt** to produce the numeric ciphertext.
6. Click **Decrypt** to recover plaintext.

## Implementation Notes

- Prime generation uses random 13-digit numbers and a Miller-Rabin style probabilistic test.
- Public exponent selection tries `65537`, then falls back to `257`, then `17`.
- The app uses fixed block sizes:
  - plaintext block size: `6` characters
  - ciphertext block size: `26` digits (left-padded with zeros)

## Limitations

- No modern RSA padding scheme (OAEP/PKCS#1 v1.5).
- Not secure for real-world cryptographic use.
- Uses global mutable state for RSA parameters.

## License

MIT License. See [LICENSE](LICENSE).
