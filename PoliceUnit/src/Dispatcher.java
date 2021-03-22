import java.util.Random;

public class Dispatcher extends Employ implements Runnable {
	private static Queue <Call> callsQ; //all the calls
	private static Queue <CrimeEvent> eventsQ; //all the events
	private static int totalCalls; //calls that need to be handled
	private static int handeledCalls =0; //calls we handled
	private Object newCall ; //synchronize between the calls

	public Dispatcher (String name, int totalCalls, Queue <CrimeEvent> eventsQ) { //constructor
		super(name, true);
		Dispatcher.totalCalls = totalCalls;
		Dispatcher.eventsQ = eventsQ;
		new Thread(this).start();
	}

	public void run() {
		if (handeledCalls == totalCalls) { //end of the day - wake up the threads
			notifyAll();
		}

		while( handeledCalls < totalCalls){ //as long as the day is not over yet - continue
			if (newCall != null ) {
				try {
					synchronized(newCall) {
						wait();
					}
				} 


				catch (InterruptedException e) {
					e.printStackTrace();
				}

				handeledCalls++; 
				Call firstC = callsQ.extract(this); //extract the first call
				eventsQ.add(new CrimeEvent(firstC.getAddress(),handeledCalls, firstC.getArrival(), firstC.getArea(), firstC.getSeverity())); 
				Random rand = new Random();
				int random = 0;
				if (firstC.getArea() == 1) {
					random = rand.nextInt(2000) + 1000;
				}

				if (firstC.getArea() == 2) {
					random = rand.nextInt(500) + 100;
				}

				if (firstC.getArea() == 3) {
					random = rand.nextInt(3000) + 2000;
				}

				try {
					Thread.sleep(((long)firstC.getTime()*1000+random));
					synchronized(firstC.getKey()) {
						firstC.getKey().notifyAll(); //wake up the threads
					}
				}
				catch (InterruptedException e) {
					e.printStackTrace();
				}

			}

		}
	}

	public void addCall(Call c){ //get all the details of the calls
		callsQ.add(c);
		newCall.notifyAll(); //wake up the threads
	}
}

