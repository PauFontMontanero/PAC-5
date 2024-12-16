# 🧮 WPF Calculator

A sophisticated calculator built with WPF that supports both basic and advanced mathematical operations, including parentheses and complex expressions. This project was developed as part of the M7 - Interface Development course.

## 📋 Table of Contents

- [System Requirements](#-system-requirements)
- [Features](#-features)
- [Installation Guide](#-installation-guide)
- [Usage Guide](#-usage-guide)
- [Examples](#-examples)
- [Technical Implementation](#-technical-implementation)
- [License and Author](#-license-and-author)
- [Conclusions](#-conclusions)

## 💻 System Requirements

- Windows Operating System
- .NET 8.0 or higher
- Visual Studio 2022 (for development)
- At least 50MB of free disk space
- Minimum 4GB RAM recommended

## ✨ Features

### Basic Operations
- Basic arithmetic operations (addition, subtraction, multiplication, division)
- Support for chained operations
- Operator precedence handling (* and / before + and -)

### Advanced Operations
- Power operations (^)
- Square root calculations (√)
- Parentheses support with multiple nesting levels
- Complex expression evaluation

### User Interface
- Error handling for invalid operations
- Keyboard NumPad support
- Clear function to reset calculations
- Real-time display of operations
- Intuitive button layout for advanced operations

## 📥 Installation Guide

1. Download the MSI installer from the latest release
2. Run the installer and follow the installation wizard
3. Launch the calculator from the created desktop shortcut or start menu

For developers:
1. Clone the repository: git clone [repository-url]
2. Open the solution file (PAC5-Calculadora.sln) in Visual Studio 2022
3. Build the solution (Ctrl + Shift + B)
4. Run the application (F5)

## 📖 Usage Guide

### Starting the Calculator
- Launch the application from the desktop shortcut or start menu
- The calculator window will appear with a clean display

### Basic Operations
- Enter numbers using the on-screen buttons or your keyboard's NumPad
- Use operation buttons (+, -, *, /) to perform calculations
- Press '=' or Enter to see the result
- Press 'C' to clear the display and start over

### Advanced Operations

Using Parentheses:
- Use ( ) to group operations
- Supports nested parentheses
- Example: (5 + 3) * 2 = 16

Power Operations:
- Use ^ for power calculations
- Example: 2 ^ 3 = 8

Square Root:
- Use √ for square root calculations
- Example: √ 16 = 4

### Error Handling
The calculator handles various error scenarios:
- Division by zero
- Invalid square root operations (negative numbers)
- Unmatched parentheses
- Missing operators between terms
- Invalid operation combinations

## 💡 Examples

Basic Calculation:
Input: 5 + 3 =
Output: 8

Advanced Operations:
Input: (5 + 3) * 2 =
Output: 16

Input: 2 ^ 3 =
Output: 8

Input: √ 16 =
Output: 4

Complex Expressions:
Input: 3 + 5 * (2 ^ 3) - √ 16 =
Output: 39

Error Handling:
Input: √ -4 =
Output: Error (Cannot calculate square root of negative number)

Input: 5 + (3 * 2 =
Output: Error (Unmatched parentheses)

## 🔧 Technical Implementation

### User Interface
- Built using WPF (Windows Presentation Foundation)
- Responsive grid layout for buttons
- Real-time display updates
- Advanced operation buttons layout

### Core Features
- Separated calculation logic into CalculadoraCore class
- Comprehensive expression parsing and validation
- Advanced error handling system
- Support for nested operations and precedence rules

### Testing
- Extensive unit test coverage using xUnit
- Test cases for all operations and error scenarios
- Validation of complex expressions and edge cases

### Architecture
- Clean separation of UI and business logic
- Robust expression parsing and validation
- Comprehensive error handling and user feedback
- Professional MSI installer for easy deployment

### Key Classes
- MainWindow: Main UI and event handling
- CalculadoraCore: Core calculation logic
- CalculadoraCoreTests: Comprehensive test suite

### Input Handling
- Support for both mouse clicks and NumPad input
- Input validation to prevent invalid operations
- Real-time display updates
- Advanced operator precedence handling

## 📝 License and Author

Author: Pau Font Montanero
Course: M7 - Interface Development
Version: 2.0
Date: December 2024
License: MIT License

## 🎯 Conclusions

This calculator project demonstrates the implementation of a professional WPF application with:
- Clean and maintainable code structure
- Comprehensive error handling
- User-friendly interface
- Support for complex mathematical operations
- Advanced operation support (powers, square roots, parentheses)
- Thorough unit testing
- Professional installation package
- Comprehensive documentation

The project successfully meets all requirements while providing a solid foundation for future enhancements and modifications. The implementation of advanced mathematical operations and robust error handling makes this calculator suitable for both basic calculations and more complex mathematical expressions.