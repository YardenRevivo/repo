import java.sql.*; 
public class DataBase {

	private Connection conn;
	private Statement stmt;


	public DataBase() { // constructor	
		try {

			Class.forName("com.mysql.jdbc.Driver");
			String url="jdbc:mysql://localhost:3306/test";
			conn=DriverManager.getConnection(url, "root", "root");
			stmt=conn.createStatement();
		} 

		catch (ClassNotFoundException err) {

			err.printStackTrace(); }
		catch (SQLException err) { 

			err.printStackTrace(); }

	}



	public void createTable(String PoliceEvents) { //CREATE TABLE METHOD
		try {
			stmt.executeUpdate("DROP TABLE IF EXISTS " + PoliceEvents);
			String createFirstTable = "CREATE TABLE " + PoliceEvents
					+ "(ID int, Location int, Distance int, level int, Address varchar(50))";
			stmt.executeUpdate(createFirstTable);
		}  catch(SQLException ex){
			ex.printStackTrace();
		}

	}


	public void insertToTable(String PoliceEvents, CrimeEvent cr) { //INSERT TO A TABLE METHOD
		String str="INSERT INTO " +PoliceEvents+" VALUES("
				+ cr.getID()+"," 
				+ cr.getArea()+ "," 
				+ cr.getDistance()+","
				+ cr.getSeverity()+ ","
				+ cr.getAddress()+","+")" ;


		try {
			stmt.executeUpdate(str);
		} catch (SQLException sql) {


			sql.printStackTrace();
		}
	}

	public String extract(String PoliceEvents,String colName) { //PULL OUT DATA METHOD
		ResultSet result=null;
		String ans="";
		String str="select * from " + PoliceEvents;
		try {
			result=stmt.executeQuery(str);
			result.next(); // move to the first line
			ans=result.getString(colName);


		} catch (SQLException e) { e.printStackTrace();	}

		return ans;

	}
}
