```markdown
# Multi-Value Dictionary App

## Description

This is a command-line application that stores a multi-value dictionary in memory. All keys and members are strings.

## Commands

- `KEYS`: Returns all the keys in the dictionary.
- `MEMBERS <key>`: Returns the collection of strings for the given key.
- `ADD <key> <member>`: Adds a member to a collection for a given key.
- `REMOVE <key> <member>`: Removes a member from a key.
- `REMOVEALL <key>`: Removes all members for a key and removes the key from the dictionary.
- `CLEAR`: Removes all keys and all members from the dictionary.
- `KEYEXISTS <key>`: Returns whether a key exists or not.
- `MEMBEREXISTS <key> <member>`: Returns whether a member exists within a key.
- `ALLMEMBERS`: Returns all the members in the dictionary.
- `ITEMS`: Returns all keys in the dictionary and all of their members.

## Build and Run Instructions

1. Ensure you have .NET Core SDK installed.
2. Clone the repository.
3. Navigate to the project directory.
4. Run `dotnet build` to build the project.
5. Run `dotnet run` to start the application.

## Example Usage

```
> ADD foo bar
) Added
> ADD foo baz
) Added
> KEYS
1) foo
> MEMBERS foo
1) bar
2) baz
> REMOVE foo bar
) Removed
> KEYS
1) foo
> REMOVE foo baz
) Removed
> KEYS
(empty set)
```
