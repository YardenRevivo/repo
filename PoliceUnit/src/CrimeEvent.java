import java.util.ArrayList;

public class CrimeEvent extends Event {
	private int ID; 
	private int area;
	private int Arrival;
	public static Queue <CrimeEvent> eventsQ;
	
	public Queue <CrimeEvent> getEventsQ() { //get event list
		return eventsQ;
	}
	
	public CrimeEvent (String Address,int ID ,int Arrival, int area, int Severity) { //constructor
		this.Address = Address;
		this.Severity = Severity;
		this.ID = ID;
		this.Arrival = Arrival;
		this.area = area;
		eventsQ.add(this);
	}
	
	public void setDistance(int distance){ // update the distance after the station worker calculate it
		this.distance = distance;
	}
	
	public String getAddress() {
		return Address;
	}
	
	public int getDistance () {
		return distance;
	}
	
	public int getSeverity() {
		return Severity;
	}
	
	public int getArea() {
		return area;
	}
	
	public int getID() {
		return ID;
	}
	
}