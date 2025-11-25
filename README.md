# Checkout-Kata

This is my solution to the Checkout-Kata problem implemented using Test-Driven Development (TDD).

## Problem Statement

In a supermarket, items are identified by SKUs (A, B, C, D). Items have unit prices and some have special offers. The checkout system must calculate the total price based on scanned items and dynamic pricing rules.

## Solution Overview

A flexible test-driven solution with the following key features:

- **Dynamic Pricing Rules**: The `Checkout` class accepts an `IEnumerable<PricingRule>` allowing pricing to change without code changes.
- **TDD Process**: I followed a strict TDD workflow. Write failing tests, implement minimal code, refactor.
- **Edge Case Handling**: Validated input, handled empty scans and ensured correct pricing for mixed offers.
