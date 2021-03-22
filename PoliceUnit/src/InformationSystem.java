import java.sql.SQLException;
import java.util.*;

public class InformationSystem {
	private static ArrayList <CrimeEvent> shortDistance;
	private static ArrayList <CrimeEvent> mediumDistance;
	private static ArrayList <CrimeEvent> longDistance;
	private HashMap<String, ArrayList <CrimeEvent>> informationSystem;	//sort the events in a list by their distance
	private boolean DayIsOver; //check if the day is over
	private static DataBase dataBase;

	public InformationSystem (){ //constructor
		informationSystem= new HashMap<String, ArrayList <CrimeEvent>>();
		DayIsOver = false;
		createDateBase();
	}

	public synchronized void addValueAndKey(String key, ArrayList <CrimeEvent> events){ //insert key and event to the collection

		informationSystem.put(key, events);

	}

	public synchronized void insert(CrimeEvent event) throws SQLException{//insert event to the information system
		double Distance = event.getDistance();
		if( Distance<=10){ // distance that lower or equal to 10 km
			ArrayList <CrimeEvent> temp =informationSystem.get("0-10");
			temp.add(event);
			insertToDataBase(event); //insert to the data base
		}
		if(Distance > 10  &&  Distance <=20){// distance that lower than 10 km or equal to 20 km 
			ArrayList <CrimeEvent> temp =informationSystem.get("11-20");
			temp.add(event);
			insertToDataBase(event);

		}		
		if(Distance > 20){ // distance that more than 20 km
			ArrayList <CrimeEvent> temp =informationSystem.get("20+");
			temp.add(event);
			insertToDataBase(event);

		}
		notifyAll();
	}

	public static void bubbleSort(ArrayList <CrimeEvent> event) { //sort the events by their severity
		for (int i=0 ; i<event.size()-1 ; i++ ) {
			for( int j=0 ; j<event.size() - i - 1; j++ ){
				if(event.get(j).getSeverity() > event.get(j+1).getSeverity())
					swap(event, j, j + 1 );
			}
		}
	}

	public static void swap (ArrayList <CrimeEvent> event, int i, int j) { //switch two places
		Collections.swap(event, i, j);
	}

	public synchronized CrimeEvent extract(){ //extract from the information system
		while(allListsAreEmpty()==true) {
			try {
				wait();
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
		}
		shortDistance =informationSystem.get("0-10");
		mediumDistance =informationSystem.get("11-20");
		longDistance =informationSystem.get("20+");
		
		
		
		//sort the lists by their severity
		bubbleSort(shortDistance);
		bubbleSort(mediumDistance);
		bubbleSort(longDistance);

		if(!shortDistance.isEmpty()){ // distance that lower or equal to 10 km
			CrimeEvent temp = shortDistance.get(0);
			shortDistance.remove(temp); //remove from info system
			return temp; 
		}

		if(!mediumDistance.isEmpty()){ // distance that lower than 10 km or equal to 20 km 
			CrimeEvent temp = mediumDistance.get(0);
			mediumDistance.remove(temp); //remove from info system
			return temp;
		}

		if(!longDistance.isEmpty()){ // distance that more than 20 km
			CrimeEvent temp = longDistance.get(0);
			longDistance.remove(temp); //remove from info system
			return temp;
		}

		else //the day is not over
			return null;

	}
	
	public boolean allListsAreEmpty() {//checks if lists are empty 
		if ((shortDistance.isEmpty())) {
			if (mediumDistance.isEmpty()) {
				if (longDistance.isEmpty()) {
					return true;
				}
			}
		}
		return false;
	}

	public synchronized boolean IsEmpty(){ //check if there is events
		ArrayList <CrimeEvent> shortDistance =informationSystem.get("0-10");
		ArrayList <CrimeEvent> mediumDistance =informationSystem.get("11-20");
		ArrayList <CrimeEvent> longDistance =informationSystem.get("20+");
		if(shortDistance.size()==0 && mediumDistance.size()==0 && longDistance.size()==0 )
			return true;
		else
			return false;
	}

	private synchronized void insertToDataBase(CrimeEvent ce) throws SQLException{// insert info to database
		dataBase.insertToTable("CrimeEvent", ce);
	}

	private void createDateBase() {// create database
		dataBase.createTable("CrimeEvent");

	}
}