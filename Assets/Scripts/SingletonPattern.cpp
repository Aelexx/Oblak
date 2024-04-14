#include <iostream>
using namespace std;

class Singleton
{
    protected:
    Singleton() = default;

    public:
    int data;

    static Singleton& get_instance()
    {
        static Singleton my_instance; //local var
        return my_instance;
    }
    //Here we prevent from copy
    Singleton (const Singleton&) = delete; // copy constructor now would be deleted func
    Singleton (Singleton&& ) = delete;
    Singleton& operator=(const Singleton&) = delete;
    Singleton& operator=(Singleton&&) = delete;



};

int main()
    {
        //Singleton bad_singleton;
        Singleton &singleton1 = Singleton::get_instance();
        singleton1.data = 10;
        cout<< "We got first data " << singleton1.data << endl;
        Singleton &singleton2 = Singleton::get_instance();
        cout << "We got second data " << singleton2.data << endl;
        Singleton::get_instance().data = 55;
        cout<<"We got third data "<<Singleton::get_instance().data<<endl;
        
        cout<< "We got first data " << singleton1.data << endl;
        cout << "We got second data " << singleton2.data << endl;

        // Singleton singletonN = singleton1; //copy constructor
        // singletonN.data = 111;
        // cout<< "singleton1 " << singleton1.data << endl;
        // cout<< "singletonN " << singletonN.data << endl;


        return 0;
    }
