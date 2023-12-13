// infix to postfix.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include <iostream>
#include <cstdlib>
#include <string>
using namespace std;

int count = 0;
string expr;

void E();
void Ed();
void T();
void Td();
void F();

int main() {
    cout << "Enter an arithmetic expression: ";
    getline(cin, expr);
    int l = expr.length();
    expr += "$";
    E();
    if (l == ::count)  // Fully qualify the 'count' identifier
        cout << "Accepted" << endl;
    else
        cout << "Rejected" << endl;

    return 0;
}

void E() {
    T();
    Ed();
}

void Ed() {
    if (expr[::count] == '+') {  // Fully qualify the 'count' identifier
        ::count++;  // Fully qualify the 'count' identifier
        T();
        Ed();
        cout << "+";
    }
    else if (expr[::count] == '-') {  // Fully qualify the 'count' identifier
        ::count++;  // Fully qualify the 'count' identifier
        T();
        Ed();
        cout << "-";
    }
}

void T() {
    F();
    Td();
}

void Td() {
    if (expr[::count] == '*') {  // Fully qualify the 'count' identifier
        ::count++;  // Fully qualify the 'count' identifier
        F();
        Td();
    }
    else if (expr[::count] == '/') {  // Fully qualify the 'count' identifier
        ::count++;  // Fully qualify the 'count' identifier
        F();
        Td();
    }
}

void F() {
    if (isalpha(expr[::count])) {  // Fully qualify the 'count' identifier
        cout << "id: " << expr[::count];  // Fully qualify the 'count' identifier
        ::count++;  // Fully qualify the 'count' identifier
    }
    else if (isdigit(expr[::count])) {  // Fully qualify the 'count' identifier
        cout << "num: " << expr[::count];  // Fully qualify the 'count' identifier
        ::count++;  // Fully qualify the 'count' identifier
    }
    else if (expr[::count] == '(') {  // Fully qualify the 'count' identifier
        ::count++;  // Fully qualify the 'count' identifier
        E();
        if (expr[::count] != ')') {  // Fully qualify the 'count' identifier
            cout << "Rejected" << endl;
            exit(0);
        }
        ::count++;  // Fully qualify the 'count' identifier
    }
    else {
        cout << "Rejected" << endl;
        exit(0);
    }
}
