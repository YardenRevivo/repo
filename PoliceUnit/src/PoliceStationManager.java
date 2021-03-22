import java.util.ArrayList;

public class PoliceStationManager extends Employ implements Runnable {
	private static int numOfDays;
	private int numOfExcpectedEvents;
	private static int eventHandeled;
	private static int CallsExpected;
	private static int SevereEvents =0;
	private boolean DayIsOver;
	private PoliceUnit station;

	public PoliceStationManager(String name, int numOfEvents, PoliceUnit Pu) { //constructor
		super(name, true);
		numOfExcpectedEvents=numOfEvents;
		DayIsOver=false;
		station= Pu;
	}

	public void run() {
		while(isRunning == true) { 
			synchronized (this) {
				while(eventHandeled!=numOfExcpectedEvents) {
					try {
						wait();
					} catch (InterruptedException e) {}
				}
				if (DayIsOver=true) {
					printEventsHandled();
					isRunning=false;
					finishDay();
				}
			}
		}
	}

	public void finishDay() { //finish the day
		station.finishDay();
	}

	public void printEventsHandled() { //print function
		System.out.println("Number of total events handled today:" + eventHandeled);
		System.out.println("Number of severe events handled today:" + SevereEvents);
	}

	public synchronized void checkEvent(ReadyEvent re) {//add the event to the total events handled and check if its severe (level 5)
		eventHandeled++;
		if (re.getSeverity()==5){
			SevereEvents++;
		}
		this.notifyAll();
	}

}
