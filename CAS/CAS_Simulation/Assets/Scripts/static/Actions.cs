public static class Actions {

	public static void Move(Entity entity, Location dir){
		Enviroment.Move(entity, dir);
	}
	
	public static void Attack(Entity entity,Location dir){
		Enviroment.Attack(entity, dir);
	}
	
	public static void Wait(Entity entity){
		Enviroment.Wait(entity);
	}
}
