#include<iostream>
#include<string>
#include<forward_list>

class Observer
{
    public:
        Observer(std::string name) : mName(name)
        {

        }
        void OnNotify()
        {
            std::cout<< mName <<" Hello"<< std::endl;
        }
    private:
        std::string mName;    
};

class Subject
{
    public:
        void AddObserver(Observer* observer)
        {
            mObservers.push_front(observer);   
        }
        void RemoveObserver(Observer* observer)
        {
            mObservers.remove(observer);
        }
        void NotifyAll()
        {
            for(auto& o : mObservers)
                o->OnNotify();
        }
    private:    
        std::forward_list<Observer*> mObservers;
};

int main()
{
    Subject subject;
    Observer observer1("ObserverA");
    Observer observer2("ObserverB");
    Observer observer3("ObserverC");

    subject.AddObserver(&observer1);
    subject.AddObserver(&observer2);
    subject.AddObserver(&observer3);

    subject.NotifyAll();
    
    return 0;
}