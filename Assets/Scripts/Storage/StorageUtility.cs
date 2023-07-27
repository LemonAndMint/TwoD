using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace Utility{

    public static class StorageUtility
    {

        /*
         * #FIXME Sadece EntityStorage erisebilir olmali ama onunla kardeslik kurmadan. \ Corpyr.
         */

        ///<summary> Verilen itemin verilen listede olup olmadigini kontrol eder ardindan  
        /// listede atanmamis en dusuk id degerini itemin Stats degerine atar. </summary> 
        public static void GiveIDtoItem<T>(List<T> storageList, T newItem)  where T : StorableStats{ 

            if(storageList.Contains(newItem)){

                int id = _getUnasinedID(storageList.ToList<StorableStats>());
                newItem.SetInGameID(id);

            }

        }

        private static int _getUnasinedID(List<StorableStats> storageList){

            List<int> idList = storageList.Select(x => x.GetInGameID()).OrderByDescending( x => x).ToList();
            int smallestIDinList = idList.First();

            if( smallestIDinList > 0 ){

                return smallestIDinList - 1;

            }
            else if ( smallestIDinList == 0 ){

                return idList.Last() + 1;

            }
            else{

                Debug.Log(" StorageUtility _getUnasinedID id degeri negatif! Id degeri: " + smallestIDinList);
                return -1;

            }

        }
    }

}
