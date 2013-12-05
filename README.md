PBKDF2.NET
==========

The current source release version of PBKDF2.NET is v2.0.0

The current binary release is available on Nuget.org at:
    http://www.nuget.org/packages/PBKDF2.NET/

v2.0.0 brings a much cleaner and flexible interface and performance optimizations.
The binary release via Nuget.org will be updated soon to reflect this update.

Provides adaptive password-based key derivation (PBKDF2) functionality for the .NET Framework allowing the use of 
any System.Security.Cryptography.HMAC-based hashing implementation, whether it's a built-in type, or an implementation 
of your own.

This utility library adheres to the suggested PBKDF2 implementation as well as adhering to the .NET programming model 
for cryptographic procedures. This allows for easily integrating with related .NET classes and other frameworks which 
expect the appropriate paradigms and base classes.

NOTE:
When using any type of resource-intensive iterative hashing functionality in a web/remote scenario, you must be sure to 
take precautions to prevent potential exploitations from maliscious users attempting to perform DOS (Denial of Service) 
attacks against your application. Due to the potential resources of a properly implemented PBKDF2 algorithm, this can 
become a dangerous threat to your server. For more information about this, read up on "Prevention of Denial of Service 
Attacks".
