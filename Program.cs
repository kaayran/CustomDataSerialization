namespace CustomDataSerialization;

public static class Program
{
    public static void Main(string[] args)
    {
        var cons = new NodeConstructor(10, 3);
        
        var inspector = new NodeInspector(cons);
        inspector.SoftInspect();

        var deployer = new NodeDeployer(cons);
        deployer.Deploy();
        
        inspector.HardInspect();
    }
}