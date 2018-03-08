# ReactiveUI.Slim

## Introduction

A work in progress experiment to see if the allocations and performance of some of the core components of ReactiveUI can be enhanced.

## Background

The desire to try and reduce allocations came from first hand experience on a Xamarin + Android solution. With quite complicated view models utilized within multiple RecyclerViews when the garbage collectors kicked in it would cause the scrolling of the lists to become quite jerky even on high end mobiles.

Usage of the .NET profiler would show a huge number of allocations within the Reactive namespace. So the question was whether anything could be done to try and reduce the memory footprint AND the total number of allocations.

As a starting point, the constructs of WhenAny within ReactiveUI have been looked at to see if anything could be done.

## Approach

The approach taken was approximately this:

*"We still want to work in a Reactive way, but could changing the internals of things like WhenAny to not be Reactive make a positive difference?"*

The library ReactiveUI.Slim is a 1st experiment to see whether this is possible or not.

## Usage

Simple, just stick the word Slim at the end of any of existing WhenAny statements e.g. instead of **WhenAnyValue** use **WhenAnyValueSlim**.

## Caveats

This code has not been heavily tested at all. It is not known if it handles nulls correctly. It doesn't use **IObservedChange** but that may have been a mistake on my behalf.

Similarly, given its just a test, there is no nuget package.

## Early performance observations

A simplistic test of populating of list with 1,000 **IDisposable** instances as a result of a subscription to a **WhenAnyValue / WhenAnyValueSlim** shows a reduction of around 65% of memory used, and around 67% reduction in number of allocations.

In another simple test of rapidly changing the value of a property 1,000 times and then measuring the time taken for propogation, this also showed an improvement of around a 90% reduction in the time taken.

I do wish to make clear though that this code has had little testing, so these improvements could be an illusion due to error that I have made.









