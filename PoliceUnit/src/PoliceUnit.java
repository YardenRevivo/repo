import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;


public class PoliceUnit {
	private static ArrayList <Dispatcher> dispatchers;
	
	private int callsCounter=0;
	private static ArrayList <EventHandler> eventHandlers;
	private static ArrayList <StationWorker> stationWorkers;
	private static ArrayList<EventCommander> eventCommander;
	private static Queue <Call> callQueue;
	private ArrayList<Call> callsList;
	private static Queue <CrimeEvent> eventsQ;
	private static int totalCalls;
	private static InformationSystem informationSystem;
	private static BoundedQueue <ReadyEvent> readyEvQ;
	private static int numOfCars=10;
	private static int numOfMotorcycles=50;
	private PoliceStationManager pSM;
	
	public PoliceUnit(int x, int y, int z, double stationWorkTime) { //constructor that start the day
		setAddNumOfMotorcycles(y);
		setAddNumOfCars(z);
		dispatchers= new ArrayList <Dispatcher>() ;
		eventHandlers= new ArrayList <EventHandler>() ;
		stationWorkers= new ArrayList <StationWorker>() ;
		eventCommander= new ArrayList <EventCommander>() ;
		callsList = new ArrayList<Call>();
		callQueue = new Queue<Call>();
		eventsQ = new Queue <CrimeEvent>();
		readyEvQ = new BoundedQueue<ReadyEvent>(15);
		readCallsFile("callsData.txt");
		totalCalls = callsList.size();
		addDispatchers(5);
		addEventHandlers(3);
		addStationWorkers(3);
		addEventCommander(x);
		createPoliceStationManager();
		runCalls();
		informationSystem = createInformationSystem();
	}
	
	public synchronized int getnumOfCars(){
		return numOfCars;
	}
	
	public synchronized int getnumOfMotorcycles(){
		return numOfMotorcycles;
	}

	public synchronized void setReduceNumOfMotorcycles(int x){
		numOfMotorcycles=numOfMotorcycles-x;
	}
	public synchronized void setAddNumOfMotorcycles(int x){
		numOfMotorcycles=numOfMotorcycles+x;
		notifyAll();
	}
	
	public synchronized void setReduceNumOfCars(int x){
		numOfCars=numOfCars-x;
	}
	public synchronized void setAddNumOfCars(int x){
		numOfCars=numOfCars+x;
		notifyAll();	
	}
	
	private static InformationSystem createInformationSystem(){ //create information system
		informationSystem = new InformationSystem();
		informationSystem.addValueAndKey("0-10" , new ArrayList<CrimeEvent>());
		informationSystem.addValueAndKey("11-20" , new ArrayList<CrimeEvent>());
		informationSystem.addValueAndKey("20+" , new ArrayList<CrimeEvent>());
		return informationSystem;
	}
	
	public void checkVehicles(int MotorNeeded, int carsNeeded) { //checks the availability of vehicles
		while(getnumOfCars()<carsNeeded || getnumOfMotorcycles()<MotorNeeded) {
			try {
				wait();
			} catch (InterruptedException e) {}
		}
	}
	
	private void addStationWorkers (int numOfEmployees) {
		
		for(int i = 0; i<numOfEmployees;i++){
			StationWorker e = new StationWorker("s"+i,totalCalls,informationSystem, readyEvQ );
			stationWorkers.add(e);
			Thread t = new Thread(e);
			t.start();
		}
	}
	
	private void addDispatchers(int numOfEmployees) {
		for(int i = 0; i<numOfEmployees;i++){
			Dispatcher e = new Dispatcher("d"+i, totalCalls, eventsQ);
			dispatchers.add(e);
			Thread t = new Thread(e);
			t.start();
		
		}
	}
	
	private void addEventHandlers(int numOfEmployees){
		for(int i = 0; i<numOfEmployees;i++){
			EventHandler e = new EventHandler("e"+i, totalCalls,informationSystem, eventsQ);
			eventHandlers.add(e);
			Thread t = new Thread(e);
			t.start();
		}
	}
	
	private void addEventCommander(int numOfEmployees){
		for(int i = 0; i<numOfEmployees;i++){
			EventCommander e = new EventCommander("e"+i, readyEvQ, this, pSM);
			eventCommander.add(e);
			Thread t = new Thread(e);
			t.start();
		}
	}
	
	private void createPoliceStationManager() {
		PoliceStationManager pSM = new PoliceStationManager("pSM", totalCalls, this);
		Thread t = new Thread(pSM);
		t.start();
	}
	
	private static void runCalls() { //start the calls
		for(int i = 0; i<callQueue.size() ;i++){
			Call c = callQueue.get(i);
			Thread t = new Thread(c);
			t.start();
		}
	}
	
	public synchronized void finishDay() { //end of the day
		changeToFalse(dispatchers);
		changeToFalse(eventHandlers);
		changeToFalse(stationWorkers);
		changeToFalse(eventCommander);
		synchronized (eventsQ) {
			this.eventsQ.notifyAll();
		}
		synchronized (callQueue) {
			this.callQueue.notifyAll();
		}
		synchronized (readyEvQ) {
			this.readyEvQ.notifyAll();
		}
	}
	
	private void changeToFalse(ArrayList <? extends Employ> E) { //change all the "isRunning" of threads to false
		for(int i=0; i<E.size(); i++) {
			E.get(i).isRunning(false);
		}	
	}
		
	private void readCallsFile(String call) { // read the info from the data file
		String configuration = call;
		try {
			FileReader fr = new FileReader(configuration);
			BufferedReader br = new BufferedReader(fr);
			String str;
			boolean first = true;
			while ((str = br.readLine()) != null) {
				if (first == true) {
					first = false;
					continue;
				}
				String[] line = str.split("\t");

				int state = Integer.parseInt(line[0]);
				int area = Integer.parseInt(line[1]);
				double time = Double.parseDouble(line[2]);
				int arrival = Integer.parseInt(line[3]);
				String address = line[4];
				// create new call from the info above
				Call ca = new Call(address, state, area, arrival, time); 
				callsCounter++; // add number of calls 
				callsList.add(ca); // add the call to the calls queue

			}
			br.close();

		} catch (IOException e) {
			System.out.println("The file " + configuration + " was not found");
		}
	}
}