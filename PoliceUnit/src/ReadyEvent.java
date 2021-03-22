
public class ReadyEvent extends Event {
	private int numOfMotorcycles;
	private int numOfCars;
	private static BoundedQueue <ReadyEvent> ReadyEQ;

	public ReadyEvent (String Address, int Severity, int distance, int motorcyclesNum,int numOfCars) { //constructor
		this.Address = Address ;
		this.Severity = Severity;
		this.distance = distance;
		this.numOfCars = numOfCars;
		this.numOfMotorcycles = motorcyclesNum;
		ReadyEQ.add(this);
	}
	
	public int getSeverity() {
		return Severity;
	}
	
	public int getnumOfMotorcycles() {
		return numOfMotorcycles;
	}
	
	public int getNumOfCars() {
		return numOfCars;
	}
	
	public int getDistance() {
		return distance;
	}
}