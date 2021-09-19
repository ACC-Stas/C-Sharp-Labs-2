using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHES.Collections;

namespace ZHES.Entities {
    class Journal {
        struct LogedEvent {
            public LogedEvent(String eventName, String description) {
                EventName = eventName;
                Description = description;
            }
            public String EventName { get; set; }
            public String Description { get; set; }
        }
        MyCustomCollection<LogedEvent> events = new MyCustomCollection<LogedEvent>();
        public void AddEvent(String eventName, string description) {
            LogedEvent newEvent = new LogedEvent(eventName, description);
            events.Add(newEvent);
        }
        public void PrintLogs() {
            events.Reset();
            Console.WriteLine("Journal logs:");
            for (int i = 0; i < events.Count; i++) {
                Console.WriteLine(events.Current().EventName + " - " + events.Current().Description);
                events.Next();
            }
            Console.WriteLine();
        }
    }
}
