
public class EventCommander extends Employ implements Runnable {
	private InformationSystem infoSys;
	private BoundedQueue<ReadyEvent> readyEventQueue;
	private PoliceUnit unit;
	private PoliceStationManager manager;

	public EventCommander(String name, BoundedQueue <ReadyEvent> events, PoliceUnit pu, PoliceStationManager manager) { //constructor
		super(name, true);
		readyEventQueue=events;
		unit=pu;
		this.manager=manager;
	}

	public void run() {
		while(isRunning == true) {
			ReadyEvent re = readyEventQueue.extract(this);
			try {
				Thread.sleep(timeOfWork(re, re.getnumOfMotorcycles(), re.getNumOfCars()));

			} catch (InterruptedException e) {
				e.printStackTrace();
			}
			unit.setAddNumOfCars(re.getNumOfCars());
			unit.setAddNumOfMotorcycles(re.getnumOfMotorcycles());
			manager.checkEvent(re);
		}
	}

	public int timeOfWork(ReadyEvent re, int numOfMotorcycles, int numOfCars) { //calculate the the time of work
		int totalVehicles= numOfMotorcycles+numOfCars;
		int time= (((re.getSeverity()*2)+re.getDistance())/(totalVehicles))*1000;
		return time;
	}
}
