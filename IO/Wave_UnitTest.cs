namespace Knv.DAQ
{
    using NUnit.Framework;
    using System.Linq;
    using System.Text;
    using IO;

    [TestFixture]
    internal class Wave_UnitTest
    {
        DaqIo _daq;

        [SetUp]
        public void TestSetup()
        { 
            _daq = new DaqIo();
            _daq.Open("COM8");
        }

        [Test]
        public void SelectWave() 
        {
            WaveForm target = WaveForm.WAVE_SINE;
            _daq.Ao1.SelectWave(target);
            var excepted = _daq.Ao1.SelectedWave();
            Assert.AreEqual(target, excepted);
        }

        [Test]
        public void ConfigWave()
        {
            _daq.Ao1.SelectWave(WaveForm.WAVE_SINE);
            _daq.Ao1.ReadConfig();
        }


        public void CofngiRead()
        { 
        
           
        
        }


        [TearDown]
        public void TestTearDown() 
        {
            if(_daq != null && _daq.IsOpen)
            {
                _daq.Close();
            }
            
        }


    }
}
