public class StationWorker extends Employ implements Runnable {
	private static int totalEvents;
	private static int handeledEvents = 0;
	private Object newEvent;
	private static InformationSystem infoSys ;
	private static BoundedQueue <ReadyEvent> readyEvQ;
	private int minOfMotorcycles=0;
	private int maxOfMotorcycles=0;
	private int numOfCars=0;
	private int numOfMotorcycles=0;
	private int availableMotorcycles;
	private int availableCars;
	private PoliceUnit unit;


	public StationWorker (String name, int totalEvents, InformationSystem infoSys, BoundedQueue <ReadyEvent> readyEvQ){ //constructor
		super(name, true);
		StationWorker.infoSys = infoSys;
		StationWorker.totalEvents = totalEvents;
		StationWorker.readyEvQ = readyEvQ;
		new Thread(this).start();
	}

	public void run() {

		while(isRunning == true) {
			CrimeEvent ce = infoSys.extract();
			if(ce!=null) {
				getNumOfVehicles(ce.getSeverity());
				unit.checkVehicles(minOfMotorcycles, numOfCars);
				if(availableMotorcycle() > maxOfMotorcycles) {
					reduceNumOfVehicles(numOfCars,maxOfMotorcycles);
					ReadyEvent re= new ReadyEvent(ce.getAddress(), ce.getDistance(), ce.getSeverity(), maxOfMotorcycles, numOfCars);
					readyEvQ.add(re);
				}
			}

			else {
				reduceNumOfVehicles(numOfCars, availableMotorcycle());
				ReadyEvent re= new ReadyEvent(ce.getAddress(), ce.getDistance(), ce.getSeverity(), availableMotorcycle(), numOfCars);
				readyEvQ.add(re);
			}			
		}
	}

	private void reduceNumOfVehicles(int carsToMission, int motoToMission) { //reduce the number of all vehicles
		unit.setReduceNumOfCars(carsToMission);
		unit.setReduceNumOfMotorcycles(motoToMission);
	}

	private void addNumOfVehicles(int carsToMission, int motoToMission) { //add to number of all vehicles
		unit.setAddNumOfCars(carsToMission);
		unit.setAddNumOfMotorcycles(motoToMission);
	}

	private int availableMotorcycle() { 
		return unit.getnumOfMotorcycles();
	}

	private int availableCars() {
		return unit.getnumOfCars();
	}

	private int getNumOfCars(CrimeEvent e) { //calculate the number of cars
		int Severity = e.getSeverity();
		if (Severity ==3) return 1;
		if (Severity ==4) return 2;
		if (Severity ==5) return 3;
		else return 0;
	}

	private void getNumOfVehicles(int severity) { //calculate the number of minimum and maximum of the motorcycles
		switch(severity) {
		case 1: 
			minOfMotorcycles=2;
			maxOfMotorcycles=3;
			numOfCars=0;
			break;
		case 2: 
			minOfMotorcycles=3;
			maxOfMotorcycles=4;
			numOfCars=0;
			break;
		case 3: 
			minOfMotorcycles=5;
			maxOfMotorcycles=6;
			numOfCars=1;
			break;
		case 4: 
			minOfMotorcycles=7;
			maxOfMotorcycles=8;
			numOfCars=2;
			break;
		case 5: 
			minOfMotorcycles=8;
			maxOfMotorcycles=10;
			numOfCars=3;
			break;
		}
	}
}
