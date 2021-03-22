import java.sql.SQLException;
import java.util.Random;

public class EventHandler extends Employ implements Runnable { 
	public static Queue <CrimeEvent> eventsQ;
	private int handeledEvents;
	private int workTime ;
	private static int totalEvents;
	private static InformationSystem informationSystem;

	public EventHandler (String name, int totalEvents, InformationSystem info, Queue <CrimeEvent> eventsQ ) { //constructor
		super(name, true);
		workTime =3;
		EventHandler.informationSystem =info;
		EventHandler.totalEvents = totalEvents;
		EventHandler.eventsQ = eventsQ;
		new Thread(this).start();
	}

	public void run(){
		if ( handeledEvents == totalEvents) //if there is no more events to handle
			
			while ( handeledEvents < totalEvents) { //as long as the day is not over
				handeledEvents++;
				eventsQ.notifyAll(); //wake up the threads
				CrimeEvent FirstE = eventsQ.extract(this);
				this.setDistance(FirstE);
				try {
					informationSystem.insert(FirstE);
				} catch (SQLException e1) {
					e1.printStackTrace();
				}
				try {
					Thread.sleep(workTime*1000);
				} catch (InterruptedException e) {
					e.printStackTrace();
				}
				System.out.println("Notice - New Emergency"+FirstE.getID());
			}
	}

	private void setDistance (CrimeEvent event) { //set the distance of the crime event
		int area = event.getArea();
		int d = getDistance(event.getAddress(), area);
		event.setDistance(d);
	}

	private int getDistance (String Address, int area) { //calculate the distance from the station
		int wordsNum = CountWords (Address) ;
		int distance =0;
		char firstL = Address.charAt(0);
		distance += addByFirstChar(firstL, area);
		return distance + wordsNum;	
	}

	private int addByFirstChar(char c, int area) {
		Random rand = new Random();
		int random = 0;

		if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')) { //if the first char is a letter
			if (area == 1) {
				random = rand.nextInt(12) + 9;
			}

			if (area == 2) {
				random = rand.nextInt(20) + 12;
			}

			if (area == 3) {
				random = rand.nextInt(10) + 8;
			}
		}

		else { //if the first char is a number
			return Character.getNumericValue(c);
		}

		return random;
	}

	private int CountWords (String str) { //count the words in the address
		int count =0;
		for(int i = 0; i < str.length(); i++){
			if(str.charAt(i) == ' '){
				count++;
			}
		}
		return count+1;
	}
}
