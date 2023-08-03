using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace Utility{

    public static class StorageUtility
    {
        public static T FindStat<T>(List<T> storageList, int id) where T : StorableStats{

            return storageList.Select( k => { if(k.GetInGameID() == id) { return k; } return null; }).ToList().First();

        }

        /*
         * #FIXME Sadece EntityStorage erisebilir olmali ama ona baglantili olmadan. \ Corpyr.
         */

        ///<summary> Verilen itemin verilen listede olup olmadigini kontrol eder ardindan  
        /// listede atanmamis en dusuk id degerini itemin Stats degerine atar. </summary> 
        public static void GiveMinID<T>(List<T> storageList, T newItem)  where T : StorableStats{ 

            int id = _mintUnasinedID(storageList.ToList<StorableStats>());
            newItem.SetInGameID(id);

            Debug.Log("id value :" + id);

        }

        private static int _mintUnasinedID(List<StorableStats> storageList){

            List<int> idList = storageList.Select(x => x.GetInGameID()).OrderBy( x => x ).ToList();
            int currentIdinList = 0;

            foreach(int id in idList){

                if(currentIdinList == id){

                    currentIdinList++;
                    continue;

                }
                else {

                    break;

                }


            }

            return currentIdinList;

        }
    }

}
