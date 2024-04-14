#include<iostream>
#include<string>
#include<vector>
using namespace std;


class Listener
{
    public:
    virtual void onEvent(string msg) = 0;

};

class Publisher
{
    vector<Listener*> listeners;

    public:
    void addListener(Listener* list)
    {
        listeners.push_back(list);
    };

    void publishEvent(string msg)
    {
        for(Listener* list : listeners)
            list->onEvent(msg);
    }
    void doSomething()
    {
        publishEvent("Hello Me, it's me again");
    }
};

class ListenerA : public Listener
{
    public:
    ListenerA(Publisher* p)
    {
        p.addListener(this);
    }
    virtual void onEvent(string msg)
    {
        cout << "Message 1" << msg << endl;
    }
};

class ListenerS : public Listener
{
    public:
    ListenerS(Publisher* p)
    {
        p.addListener(this);
    }
    virtual void onEvent(string msg)
    {
        cout << "Message 2" << msg << endl;
    }
};

int main()
{
    Publisher p;
    ListenerA* aptr = new ListenerA(p);
    ListenerS* sptr = new ListenerS(p);

    p.doSomething();
    delete aptr;
    delete sptr;

};