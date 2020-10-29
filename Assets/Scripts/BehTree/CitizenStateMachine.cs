//using UnityEngine;

//public class CitizenStateMachine : MonoBehaviour
//{
//    public BehTree BehTree;
//    public Citizen Citizen;

//    public BedTomatos bedTomatos;

//    private void Start()
//    {
//        var root = new BTSelector("Root");
//        {
//            var selectorJob = new BTSelector("Я на работе?");
//            {
//                //Работаем
//                var isJob = new BTCondition("Я уже на работе?", () => Citizen.currentBuilding == Citizen.job);
//                var isTired = new BTCondition("Я полон сил?", () => Citizen.stamina.Value >= 1);
//                var moveToJob = new MoveState("Идем", Citizen.transform, Citizen.job.transform.position, 1f);
//                var enterToJob = new BTAssign("Входим в здание", () => { Citizen.currentBuilding = Citizen.job; });
//                var job = new JobState("Работаем", Citizen.job, Citizen, Citizen.profession.uid);
                
//                var iJobSeq = new BTSequencer("Процесс работы");
//                {
//                    iJobSeq.AddState(isJob);
//                    iJobSeq.AddState(isTired);
//                    iJobSeq.AddState(job);
//                }
//                selectorJob.AddState(iJobSeq);

//                //Идем на работу
//                var moveToJobSeq = new BTSequencer("Идем на работу и входим в здание");
//                {
//                    moveToJobSeq.AddState(moveToJob);
//                    moveToJobSeq.AddState(enterToJob);
//                }
//                selectorJob.AddState(moveToJobSeq);
//            }
//            root.AddState(selectorJob);
//        }

//        var selectorForRest = new BTSelector("Я устал?");
//        {
//            var isTired = new BTCondition("Я полон сил?", () => Citizen.stamina.Value < 1);
//            var moveToHome = new MoveState("Идем домой", Citizen.transform, Citizen.home.transform.position, 1f);
//            var enterToHome = new BTAssign("Входим в дом", () => { Citizen.currentBuilding = Citizen.home; });
//            var waitRest = new BTWaitCondition("Ждем когда восстановится силы", () => Citizen.stamina.Value >= Citizen.stamina.MaxValue);

//            var ihomeSeq = new BTSequencer("Процесс дома");
//            {
//                ihomeSeq.AddState(isTired);
//                ihomeSeq.AddState(moveToHome);
//                ihomeSeq.AddState(enterToHome);
//                ihomeSeq.AddState(waitRest);
//            }
//            selectorForRest.AddState(ihomeSeq);
            
//        }

//        root.AddState(selectorForRest);
//        BehTree.AddState(root);
        

//    }
//}