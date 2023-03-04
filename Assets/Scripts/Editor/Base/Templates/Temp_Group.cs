using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MyEditor {
    public partial class EditorTemplate : Editor {
        public class Group {
            // グループの方向指定
            static GUI.Scope SetGroupDirection(Direction direction = Direction.vertical, bool isColored = false)
            {
                switch (direction) {
                    case Direction.vertical:
                        return isColored ? new GUILayout.VerticalScope(GUI.skin.box) : new GUILayout.VerticalScope();

                    case Direction.horizontal:
                        return isColored ? new GUILayout.HorizontalScope(GUI.skin.box) : new GUILayout.HorizontalScope();
                }

                return null;
            }

            //--------------------------------------------------

            /// <summary>
            /// グループ化
            /// </summary>
            public static void Grouping(Direction direction, bool isColored, Action action)
            {
                using (SetGroupDirection(direction, isColored)) {
                    action?.Invoke();
                    Space();
                }
            }

            /// <summary>
            /// 開閉できるグループを作成
            /// </summary>
            public static bool Folder(bool folderFlag, string itemName, Direction direction, Action folderAction)
            {
                Grouping(direction, false, () =>
                {
                    folderFlag = EditorGUILayout.BeginFoldoutHeaderGroup(folderFlag, itemName);

                    using (var grp=new EditorGUILayout.HorizontalScope()) {
                        Space(SpaceType.horizontal);

                        // 開いている状態のとき、Action実行
                        if (folderFlag) {
                            folderAction?.Invoke();
                        }
                    }

                    EditorGUILayout.EndFoldoutHeaderGroup();
                });
                return folderFlag;
            }

            /// <summary>
            ///  有効化、無効化できるグループ
            /// </summary>
            public static bool ToggleGroup(bool toggleFlag, string itemName, Direction direction, Action action)
            {
                using (var group = new EditorGUILayout.ToggleGroupScope(itemName, toggleFlag)) {
                    using (var grp = new EditorGUILayout.HorizontalScope()) {
                        toggleFlag = group.enabled;

                        Space(SpaceType.horizontal);            // スペースで階層関係わかりやすくする
                        Grouping(direction, false, action);
                    }
                }

                return toggleFlag;
            }
        }
    }
}