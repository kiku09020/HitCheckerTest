using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MyEditor {
    public partial class EditorTemplate : Editor {
        public class Group {
            // �O���[�v�̕����w��
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
            /// �O���[�v��
            /// </summary>
            public static void Grouping(Direction direction, bool isColored, Action action)
            {
                using (SetGroupDirection(direction, isColored)) {
                    action?.Invoke();
                    Space();
                }
            }

            /// <summary>
            /// �J�ł���O���[�v���쐬
            /// </summary>
            public static bool Folder(bool folderFlag, string itemName, Direction direction, Action folderAction)
            {
                Grouping(direction, false, () =>
                {
                    folderFlag = EditorGUILayout.BeginFoldoutHeaderGroup(folderFlag, itemName);

                    using (var grp=new EditorGUILayout.HorizontalScope()) {
                        Space(SpaceType.horizontal);

                        // �J���Ă����Ԃ̂Ƃ��AAction���s
                        if (folderFlag) {
                            folderAction?.Invoke();
                        }
                    }

                    EditorGUILayout.EndFoldoutHeaderGroup();
                });
                return folderFlag;
            }

            /// <summary>
            ///  �L�����A�������ł���O���[�v
            /// </summary>
            public static bool ToggleGroup(bool toggleFlag, string itemName, Direction direction, Action action)
            {
                using (var group = new EditorGUILayout.ToggleGroupScope(itemName, toggleFlag)) {
                    using (var grp = new EditorGUILayout.HorizontalScope()) {
                        toggleFlag = group.enabled;

                        Space(SpaceType.horizontal);            // �X�y�[�X�ŊK�w�֌W�킩��₷������
                        Grouping(direction, false, action);
                    }
                }

                return toggleFlag;
            }
        }
    }
}