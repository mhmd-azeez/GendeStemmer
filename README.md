﻿# Gende Stemmer - گەندە ستێمەر
Gende Stemmer is a grammatically ignorant stemmer for Sorani Kurdish. Our aim is to make its output predictable and consistent, but not necessarily grammatically correct.

Why is this useful? It's useful for Full Text Searching indexing and other Information Retrieval (IR) tasks. It's useful to be able to stem both `سێوەکانیشتان` and `سێوێکی` back to `سێو`.

Sometimes the output of the stemmer is very ugly, but as long as it is predictable and consistent we don't mind.

**NOTE:** Please note that this project is just a Proof Of Concept (POC) and doesn't work in every scenario. If you run into edge cases, please open an issue.

## ‌How to use

Stem one word:

```csharp
var word = "بزنەکانیشتان";
var stemmed = Stemmer.StemWord(word);
// stemmed: بزن
```

Stem a body of text:

```csharp
var text = "سڵاومان گەیاندە هەموویان";
var stemmed = Stemmer.Stem(text);
// stemmed: سڵاو گەیاند هەموو
```