public class DistantEncounter {

	private readonly int _distance;
	private readonly Location _location;
	
	public DistantEncounter(int distance, Location location){
		_distance = distance;
		_location = location;
	}

	public int Distance(){return _distance;}
	public Location Location(){return _location;}
}
