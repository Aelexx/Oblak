#include<iostream>
#include<string>
#include<vector>
using namespace std;

class Shape
{
    public:
        virtual string getName() = 0;
};

class Triangle : public Shape
{
    public:
    string getName() {return "Triangle";}
};

class Square : public Shape
{
    public:
    string getName() {return "Square"; }
};

class Circle : public Shape
{
    public:
    string getName() {return "Circle"; }
};

enum Type{TRIANGLE, SQUARE, CIRCLE};

class Factory
{
    public:
    Shape* create(Type tp) // it is a factory method
    {
        switch (tp)
        {
            case TRIANGLE:
                return new Triangle();
            case SQUARE:
                return new Square();
            case CIRCLE:
                return new Circle();    
        }
    }
};

int main()
{
    vector<Shape*> shapes;
    Factory ft;
    shapes.push_back(ft.create(TRIANGLE));
    shapes.push_back(ft.create(SQUARE));
    shapes.push_back(ft.create(CIRCLE));

    for(Shape*& s : shapes)
        cout << s->getName() << endl;

    //clean up    
    for(Shape*& s : shapes)
        delete s;
    shapes.clear();
    return 0;
}