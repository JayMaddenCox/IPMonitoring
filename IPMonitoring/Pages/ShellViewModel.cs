using System;
using ControlzEx;
using Stylet;
using IPMonitoring;
using IPMonitoring.Models;

namespace IPMonitoring.Pages
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IHandle<OnStartIP>, IHandle<ReturnToMachine>
    {
        public MachineSelectViewModel MachineSelect { get; private set; }
        public MonitorIPViewModel MonitorIp { get; private set; }


        public ShellViewModel(MachineSelectViewModel machineSelect, IEventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);

            this.Items.Add(machineSelect);

            this.ActiveItem = machineSelect;
        }
        
        public void Handle(OnStartIP message)
        {
            MonitorIp = new MonitorIPViewModel(message.SelectedFilePath);
            this.Items.Add(MonitorIp);
            this.ActiveItem = MonitorIp;
        }

        public void Handle(ReturnToMachine message)
        {
            throw new NotImplementedException();
        }
    }
}
